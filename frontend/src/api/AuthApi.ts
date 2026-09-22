import axios from "axios";
import type { LoginCommand, AuthResponseDto } from "./types";

const API_BASE_URL = "http://localhost:5017/api/Admin";

export const loginUser = async (
  command: LoginCommand,
): Promise<AuthResponseDto> => {
  const response = await axios.post<AuthResponseDto>(API_BASE_URL, command);
  return response.data;
};
