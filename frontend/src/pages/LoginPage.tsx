import { useState } from "react";

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const loginUser = () => {
    console.log(email);
    console.log(password);
  };

  return (
    <>
      <main>
        <h1 className="text-3xl font-bold flex justify-center">Login</h1>

        <div className="flex flex-col gap-3 items-center m-5">
          <input
            type="text"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email"
            className="w-1/2 border rounded p-2"
          />
          <input
            type="text"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Password"
            className="w-1/2 border rounded p-2"
          />
          <button onSubmit={loginUser} className="p-2 rounded bg-blue-700">
            Login
          </button>
        </div>
      </main>
    </>
  );
};

export default LoginPage;
