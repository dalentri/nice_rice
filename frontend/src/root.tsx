import {
  Link,
  Links,
  Meta,
  Outlet,
  Scripts,
  ScrollRestoration,
} from "react-router";
import {
  QueryClient,
  QueryClientProvider,
  useQuery,
} from "@tanstack/react-query";
import "./index.css";
import Can from "./Can.tsx";

const queryClient = new QueryClient();

export default function Root() {
  return (
    <QueryClientProvider client={queryClient}>
      <html lang="en">
        <head>
          <meta charSet="utf-8" />
          <Meta />
          <Links />
        </head>
        <body>
          <nav className="flex items-center">
            <Link to="/" className="flex  font-bold text-3xl m-2 ml-4">
              Nice Rice
            </Link>
            <Can requiredRole="Admin">
              <Link to="/admin">Admin</Link>
            </Can>
            <Link to="/login">Login</Link>
          </nav>
          <Outlet />
          <ScrollRestoration />
          <Scripts />
        </body>
      </html>
    </QueryClientProvider>
  );
}
