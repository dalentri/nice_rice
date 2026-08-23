import { Link } from "react-router";

function HomePage() {
  return (
    <>
      <main>
        <div className="flex flex-col gap-4 items-center justify-center min-h-svh">
          <h1 className="">Nice Rice</h1>
          <p>
            Linux is the future. Make your introduction to the future easier
            (and beautiful).
          </p>
          <Link to="/gallery" className="p-2 bg-blue-800 rounded-lg">
            All Rices
          </Link>
        </div>
      </main>
    </>
  );
}

export default HomePage;
