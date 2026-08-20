import axios from "axios";
import type { RiceItemDto, CreateRiceItemCommand } from "./types";

const API_BASE_URL = "http://localhost:5017/api/RiceItems";

export const getRiceItems = async (): Promise<RiceItemDto[]> => {
  // Send a GET request
  const response = await axios.get<RiceItemDto[]>(API_BASE_URL);

  return response.data;
};

export const CreateRiceItem = async (
  command: CreateRiceItemCommand,
): Promise<number> => {
  const response = await axios.post<number>(API_BASE_URL, command);

  return response.data;
};
