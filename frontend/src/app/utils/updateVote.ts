export function updateVote(object: any, vote: boolean) {
  const currVote = object.votes;

  if (object.voted != null) {
    if (object.voted) {
      object.voted = vote ? null : false;
      object.votes = currVote - (vote ? 1 : 2);
    } else {
      object.voted = vote ? true : null;
      object.votes = currVote + (vote ? 2 : 1);
    }
  } else {
    object.voted = vote;
    object.votes = currVote + (vote ? 1 : -1);
  }
}
