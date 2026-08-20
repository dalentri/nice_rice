import { useState, useEffect } from "react";
import { getRiceItems } from "./api/riceItemsApi";
import type { RiceItemDto } from "./api/types";
import "./App.css";

function App() {
  const [items, setItems] = useState<RiceItemDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    getRiceItems()
      .then((data) => {
        setItems(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching rice items:", error);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading Rice Items...</p>;

  return (
    <>
      <div>
        <h1>Linux Rice Gallery</h1>
        <p>
          Linux is the future. Make your introduction to the future easier (and
          beautiful).
        </p>
        <ul>
          {items.map((item) => (
            <li key={item.id}>
              <strong>{item.title}</strong> - Downloads: {item.downloads}
            </li>
          ))}
        </ul>
      </div>
    </>
  );
}

export default App;
