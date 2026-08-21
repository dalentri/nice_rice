import { RouterProvider } from "react-router";
import { router } from "./router"; // We'll create this file next!

export default function App() {
  return <RouterProvider router={router} />;
}
