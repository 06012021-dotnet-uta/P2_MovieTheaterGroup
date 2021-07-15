import { Movie } from './movie';

export interface Theater {
  theaterId: number,
  theaterLoc: string,
  theaterName: string,
  movies: Movie[]
}
