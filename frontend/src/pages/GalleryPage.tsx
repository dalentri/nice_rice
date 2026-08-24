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
        <h1 className="flex font-bold text-2xl justify-center">Gallery</h1>
        <ul className="flex flex-row w-full">
          {items.map((item) => (
            <li
              key={item.id}
              className="p-5 m-4 w-1/3 bg-blue-900 rounded-2xl flex flex-col"
            >
              <strong>{item.title}</strong> Downloads: {item.downloads}
            </li>
          ))}
        </ul>
      </main>
    </>
  );
}

export default GalleryPage;
