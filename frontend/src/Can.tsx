import { useContext, type ReactNode } from "react";
import { AuthContext } from "./AuthContext.tsx";

interface CanProps {
  requiredRole: string;
  children: ReactNode;
}

const Can = ({ requiredRole, children }: CanProps) => {
  const auth = useContext(AuthContext);

  if (auth?.role !== requiredRole) {
    return null;
  }

  return <>{children}</>;
};

export default Can;
