export interface MovieComments {
    commentId: number,
    movieId: string,
    userId: number,
    content: string,
    dateMade: string,
    username: string
}

export interface MovieCommentsMap {
    movieId: string,
    userId: number,
    content: string
}
