import { IBaseEntity } from "./base-entity";
import { IGame } from "./game";

export interface ISession extends IBaseEntity {
    startDate: Date;
    finishDate: Date | undefined;
    game: IGame;
}