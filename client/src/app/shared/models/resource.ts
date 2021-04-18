import { IBaseEntity } from "./base-entity";

export interface IResourceDto extends IBaseEntity {
    name: string;
    resourceUrl: string;
}