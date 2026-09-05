import axios from "axios";
import type { AdminRiceItemDto } from "./types";

const API_BASE_URL = "http://localhost:5017/api/Admin";

export const getAdminRiceItems = async (): Promise<AdminRiceItemDto[]> => {
  // Send a GET request
  const response = await axios.get<AdminRiceItemDto[]>(API_BASE_URL);
  return response.data;
};
