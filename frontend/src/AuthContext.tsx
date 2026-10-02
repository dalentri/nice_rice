import { createContext, useState, useEffect, type ReactNode } from "react";
import { jwtDecode } from "jwt-decode";

const ROLE_CLAIM =
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

const getRoleFromToken = (token: string | null): string | null => {
  if (!token) return null;
  try {
    const decoded: Record<string, any> = jwtDecode(token);
    return decoded[ROLE_CLAIM] || decoded.role || null;
  } catch {
    return null;
  }
};

interface AuthContextType {
  token: string | null;
  role: string | null;
  login: (newToken: string) => void;
  logout: () => void;
}

export const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [token, setToken] = useState<string | null>(null);
  const [role, setRole] = useState<string | null>(null);

  useEffect(() => {
    const savedToken = localStorage.getItem("token");
    if (savedToken) {
      setToken(savedToken);
      setRole(getRoleFromToken(savedToken));
    }
  }, []);

  const login = (newToken: string) => {
    localStorage.setItem("token", newToken);
    setToken(newToken);
    setRole(getRoleFromToken(newToken));
  };

  const logout = () => {
    localStorage.removeItem("token");
    setToken(null);
    setRole(null);
  };

  return (
    <AuthContext.Provider value={{ token, role, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
