export interface Post {
  id: number;
  userID: number;
  username: string;
  body: string;
  title: string;
  commentsNumber: number;
  votes: number;
  voted: boolean | null;
}
