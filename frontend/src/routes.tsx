import {
  type RouteConfig,
  route,
  index,
  layout,
} from "@react-router/dev/routes";

export default [
  index("./pages/HomePage.tsx"),
  route("gallery", "./pages/GalleryPage.tsx"),
] satisfies RouteConfig;
