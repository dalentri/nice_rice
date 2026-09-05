export interface RiceItemDto {
  id: number;
  title: string;
  downloads: number;
  downloadLink: string;
}

export interface AdminRiceItemDto {
  id: number;
  title: string;
  downloads: number;
  downloadLink: string;
  isActive: boolean;
  createdBy: string;
  createdDate: string;
}

export interface CreateRiceItemCommand {
  title: string;
  downloadLink: string;
}
