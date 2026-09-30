import { useState, useContext } from "react";
import { useMutation } from "@tanstack/react-query";
import { AuthContext } from "../AuthContext";
import { useNavigate } from "react-router";
import { createUser } from "../api/AuthApi";

const CreateUserPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const auth = useContext(AuthContext);
  const navigate = useNavigate();

  const createUserMutation = useMutation({
    mutationFn: createUser,
    onSuccess: (data) => {
      console.log("Logged in successfully.", data);
      navigate("/login");
    },
  });

  return (
    <div>
      {" "}
      <main>
        <h1 className="text-3xl font-bold flex justify-center">
          Create an Account
        </h1>

        <form
          onSubmit={(e) => {
            e.preventDefault();
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
            disabled={createUserMutation.isPending}
            className="p-2 rounded bg-blue-700"
          >
            Create Account
          </button>
        </form>
        {errorMessage && <p className="">{errorMessage}</p>}
      </main>
    </div>
  );
};

export default CreateUserPage;
