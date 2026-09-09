import { useEffect, useState } from "react";
import { getAdminRiceItems } from "../api/adminApi.ts";
import { type AdminRiceItemDto } from "../api/types.ts";

function AdminPage() {
  const [items, setItems] = useState<AdminRiceItemDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    getAdminRiceItems()
      .then((data) => {
        setItems(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching admin Rice items: " + error);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading admin rice items...</p>;

  return (
    <>
      <main>
        <h1 className="text-3xl font-bold flex justify-center">Admin</h1>
        <ul>
          {items.map((item) => (
            <li
              key={item.id}
              className="p-5 m-4 w-1/3 bg-blue-900 rounded-2xl flex flex-col"
            >
              <strong>{item.title}</strong>
              <p>Downloads: {item.downloads}</p>
              <p>Author: {item.createdBy}</p>
              <p>Link: {item.downloadLink}</p>
              <p>Active: {item.isActive}</p>
              <p>Created: {item.createdDate}</p>
            </li>
          ))}
        </ul>
        <h1 className="flex justify-center font-bold text-3xl ">Admin</h1>
        <div>
          {items.map((item) => (
            <li key={item.id}>
              <h3>{item.title}</h3>
            </li>
          ))}
        </div>
      </main>
    </>
  );
}

export default AdminPage;
