import { createBrowserRouter } from "react-router";
import HomePage from "./pages/HomePage";
import GalleryPage from "./pages/GalleryPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "/Gallery",
    element: <GalleryPage />,
  },
]);
