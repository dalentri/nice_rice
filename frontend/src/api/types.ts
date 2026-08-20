export interface RiceItemDto {
  id: number;
  title: string;
  downloads: number;
  download_link: string;
}

export interface CreateRiceItemCommand {
  title: string;
  download_link: string;
}
