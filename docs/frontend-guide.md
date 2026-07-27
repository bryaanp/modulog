# Frontend guide: React and TypeScript from first principles

This guide explains not only what the Modulog frontend does, but why it is
structured this way. Read it with the source open in VS Code.

## 1. The mental model

The browser loads `index.html`, which contains an empty element named `root`.
[`client/src/main.tsx`](../client/src/main.tsx) asks React to render the
application into that element.

A React application is a tree of **components**. A component is a TypeScript
function that returns JSX, a syntax that resembles HTML:

```tsx
function Greeting() {
  return <h1>Hello</h1>
}
```

React calls the function and keeps the browser DOM synchronized with the JSX it
returns.

Four concepts appear throughout this project:

- **Props** are inputs passed from a parent component to a child.
- **State** is data owned by a component that can change over time.
- **Hooks** are functions such as `useState` and `useQuery` that connect a
  component to state, server data, or browser behavior.
- **Context** makes a shared value available to many components without passing
  it manually through every intermediate component.

TypeScript adds compile-time descriptions of data. For example, `Problem`
describes the exact fields the API returns. TypeScript prevents using a field
that does not exist, but it does not validate untrusted data at runtime.

## 2. Read the source in this order

1. [`src/main.tsx`](../client/src/main.tsx) — assembles the application-wide
   providers.
2. [`src/App.tsx`](../client/src/App.tsx) — maps URLs to pages.
3. [`src/types/api.ts`](../client/src/types/api.ts) — describes API data.
4. [`src/auth/AuthContext.tsx`](../client/src/auth/AuthContext.tsx) — manages
   login, refresh, logout, and authenticated requests.
5. [`src/components/ProtectedRoute.tsx`](../client/src/components/ProtectedRoute.tsx)
   — prevents anonymous access to application pages.
6. [`src/components/AppShell.tsx`](../client/src/components/AppShell.tsx) —
   provides navigation around the current page.
7. One page in `src/pages` at a time, beginning with `ProblemsPage.tsx`.
8. [`src/index.css`](../client/src/index.css) — visual rules shared by the
   components.

This order moves from application assembly to individual features.

## 3. Why the application uses providers

`main.tsx` wraps the application with three providers:

```text
BrowserRouter
└── QueryClientProvider
    └── AuthProvider
        └── App
```

`BrowserRouter` keeps React synchronized with the browser URL.

`QueryClientProvider` manages data fetched from the API, including loading,
errors, caching, and refetching.

`AuthProvider` owns the current session and gives pages one authenticated
`request` function.

### Alternative: pass everything as props

Passing values as props is best for local relationships. Passing authentication
through every component would create "prop drilling": intermediate components
would receive authentication values they do not use. Context is a better fit
for truly application-wide state.

### Alternative: Redux

Redux is valuable for large applications with complex client-owned state and
strict event tracing. Modulog currently has little global client state:
authentication is global, while most data belongs to the server. Redux would
add actions, reducers, and another debugging model without solving a current
problem.

## 4. Routing choice

React Router maps URLs to components:

```text
/                 Overview
/problems         Problem bank
/practice         Attempt form
/entries          Practice history
/system-design    Prompt generation
/admin/problems   Admin-only problem management
```

URLs make browser back/forward buttons, bookmarks, refreshes, and direct links
work naturally.

### Alternative: one component with a selected-tab variable

A single component can switch pages with `useState`, but the selected page
would not be represented in the URL. That approach is acceptable for a small
embedded widget, not a multi-page dashboard.

## 5. Server state with TanStack Query

Data such as problems and entries is **server state**: PostgreSQL and the API are
the source of truth. TanStack Query handles:

- loading and error states;
- short-lived caching;
- avoiding unnecessary duplicate requests;
- invalidating old data after a mutation.

For example, after an attempt is saved, `PracticePage` invalidates queries.
The overview, history, and recommendation therefore fetch updated information.

### Alternative: `useEffect` and `fetch`

Manual `useEffect` code works, but every page would need to implement loading,
errors, cancellation, stale data, and refetching. That repetition tends to
produce inconsistent behavior. TanStack Query is a focused dependency for a
problem the application already has.

## 6. Authentication and token storage

The backend returns a short-lived access token and a rotating refresh token.

The frontend keeps:

- the access token in React memory;
- the refresh token in `sessionStorage`.

On page reload, `AuthProvider` exchanges the stored refresh token for a new
token pair before rendering protected pages.

`sessionStorage` is isolated to the browser tab and is cleared when that tab is
closed. This is a compromise for the API's bearer-token design:

- It survives page refreshes, unlike memory-only storage.
- It is less persistent than `localStorage`.
- JavaScript can still read it, so preventing cross-site scripting remains
  important.

### Alternative: memory only

Memory-only tokens have less exposure to injected scripts that run later, but a
page refresh immediately logs the user out. This is secure but frustrating for
normal dashboard use.

### Alternative: `localStorage`

`localStorage` survives browser restarts, but any successful cross-site
scripting attack can read a long-lived refresh token. Modulog does not need that
degree of persistence.

### Alternative: an HttpOnly secure cookie

JavaScript cannot read an HttpOnly cookie, making it the preferred browser-only
refresh-token design in many systems. Modulog's API deliberately uses explicit
bearer tokens so the same contract can support a future native iOS client.
A later browser-specific backend-for-frontend could add cookie handling without
changing the native-client flow.

### Coordinating refreshes

Refresh tokens are single-use. If several API calls receive `401` together and
all try to refresh, only one can succeed. `AuthProvider` stores one shared
refresh promise in a ref. Other requests await that promise and reuse the new
access token.

The backend independently enforces the same rule with a PostgreSQL row lock.
Frontend coordination improves the user experience; backend enforcement
provides security.

## 7. TypeScript choices

API interfaces live in `src/types/api.ts`. Keeping them centralized makes
contract changes easy to find.

State uses narrow types where possible:

```ts
type Difficulty = 'Easy' | 'Medium' | 'Hard'
```

This is safer than a general `string`: TypeScript rejects `"Extreme"` before
the request is sent.

The project does not currently use a runtime schema library such as Zod.
TypeScript disappears after compilation and cannot prove that a network
response matches an interface. Zod would add runtime validation and is worth
considering when the API becomes public or independently versioned. For this
same-repository Phase 1 client, centralized types plus backend integration tests
keep the implementation smaller.

## 8. Form choice

Forms use controlled inputs:

```tsx
const [email, setEmail] = useState('')

<input
  value={email}
  onChange={(event) => setEmail(event.target.value)}
/>
```

React state is the current value, and `onChange` updates it.

### Alternative: React Hook Form

React Hook Form reduces boilerplate and re-renders in large, heavily validated
forms. Modulog's current forms are short. Native controlled inputs make the
data flow easier to learn and avoid another abstraction. Adopt a form library
if forms become nested, dynamic, or validation-heavy.

## 9. Styling choice

The project uses one plain CSS file with design tokens at the top:

```css
:root {
  --forest: #173f32;
  --paper: #f4f2ea;
}
```

This teaches standard browser layout, responsive media queries, focus states,
and CSS variables without requiring framework-specific syntax.

### Alternative: Tailwind CSS

Tailwind can make component-local styling fast and consistent, especially for a
team already fluent in its utility vocabulary. It would place many style
decisions inside JSX and add a second syntax for a new React learner.

### Alternative: CSS Modules

CSS Modules prevent accidental class-name collisions. They are a good next step
if the stylesheet becomes difficult to navigate. The current names are
feature-specific and the application is still small enough for one stylesheet.

## 10. Feature data flows

### Login

```text
Login form
→ POST /api/v1/auth/login
→ AuthProvider stores the token pair
→ ProtectedRoute allows the application shell
→ dashboard queries execute
```

### Log an attempt

```text
PracticePage loads curated problems
→ user submits effort and confidence
→ POST /api/v1/entries
→ cached queries are invalidated
→ history, weak topics, and recommendation refetch
```

### Recommendation

The frontend only displays the API result. Weak-topic scoring and problem
selection remain backend services because they must be consistent across the
web client and future native clients.

### Admin access

The JWT contains the `admin` role. The frontend hides the admin link and
redirects non-admin users. This improves usability, but it is not the security
boundary. The API still requires the role for every write.

## 11. Testing strategy

Vitest runs tests in a simulated browser environment. React Testing Library
interacts with rendered components through accessible labels and roles rather
than private component details.

Current tests cover:

- decoding Identity claims from the access token;
- rejecting malformed JWTs;
- client-side password-confirmation behavior.

The backend suite separately exercises the real PostgreSQL authentication,
entry, refresh, and CORS flows.

Good future tests include:

- automatic refresh after a `401`;
- problem filtering;
- successful attempt submission and query invalidation;
- a Playwright end-to-end test against the running API.

## 12. How to add a feature

Use this sequence:

1. Add or update the API type in `src/types/api.ts`.
2. Add a page or component with one clear responsibility.
3. Fetch server state through `useQuery`.
4. Change server state through `useMutation`.
5. Invalidate only the affected query keys.
6. Add loading, empty, error, and success states.
7. Add a route if the feature deserves its own URL.
8. Add a focused behavior test.
9. Run lint, tests, and the production build.

## 13. Intentional Phase 1 limitations

- Refresh tokens use `sessionStorage`, with the tradeoff described above.
- API types are compile-time only; runtime schema validation is deferred.
- Admin problem editing is available through the API, while the first UI
  exposes create and delete. Inline editing can be added when needed.
- OpenAI prompt generation requires a server-side API key.
- Email verification delivery is deferred by the backend plan.
- No frontend is deployed yet; local manual testing comes before production
  hosting.
