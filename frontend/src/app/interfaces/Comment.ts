export interface Comment {
  id: number;
  userID: number;
  commentID: number;
  username: string;
  body: string;
  commentsNumber: number;
  votes: number;
  voted: boolean | null;
  isEditing: boolean;
}
