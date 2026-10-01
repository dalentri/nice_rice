import { useState, useContext } from "react";
import { loginUser } from "../api/AuthApi";
import { useMutation } from "@tanstack/react-query";
import { AuthContext } from "../AuthContext";
import { Link, useNavigate } from "react-router";
import axios from "axios";

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const auth = useContext(AuthContext);
  const navigate = useNavigate();

  const loginMutation = useMutation({
    mutationFn: loginUser,
    onSuccess: (data) => {
      console.log("Logged in successfully.", data);
      auth?.login(data.token);
      navigate("/");
    },
    onError: (error) => {
      console.error("Login failed.", error);
      if (axios.isAxiosError(error)) {
        // TypeScript now knows 'error' is an AxiosError!
        console.log("Server response:", error.response?.data);
        setErrorMessage(error.response?.data?.detail || "Login failed");
      } else {
        setErrorMessage(error.message);
      }
    },
  });

  return (
    <>
      <main>
        <h1 className="text-3xl font-bold flex justify-center">Login</h1>

        <form
          onSubmit={(e) => {
            e.preventDefault();
            loginMutation.mutate({ email, password });
          }}
          className="flex flex-col gap-3 items-center m-5"
        >
          <input
            value={email}
            type="text"
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email"
            className="w-1/2 border rounded p-2"
          />
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Password"
            className="w-1/2 border rounded p-2"
          />
          <button
            type="submit"
            disabled={loginMutation.isPending}
            className="p-2 rounded bg-blue-700"
          >
            Login
          </button>
        </form>
        {errorMessage && <p className="">{errorMessage}</p>}
        <Link to="/create_user" className="flex justify-center">
          Create Account
        </Link>
      </main>
    </>
  );
};

export default LoginPage;
