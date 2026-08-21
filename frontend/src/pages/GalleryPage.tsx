import type { RiceItemDto } from "../api/types";
import { useState, useEffect } from "react";
import { getRiceItems } from "../api/riceItemsApi";

function GalleryPage() {
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
      <main>
        <h1>Gallery</h1>
        <ul>
          {items.map((item) => (
            <li key={item.id}>
              <strong>{item.title}</strong> - Downloads: {item.downloads}
            </li>
          ))}
        </ul>
      </main>
    </>
  );
}

export default GalleryPage;
