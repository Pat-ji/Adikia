using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class Seed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            await TheOrientExpress(context);
        }

        private static async Task TheOrientExpress(StoreContext context)
        {
            if (await context.Games.AnyAsync()) return;

            Game game = new Game
            {
                Name = "The Oriënt Express",
                ResourceUrl = "games/the_orient_express/logo.png",
                CompletedGameStage = 100,
            };

            var dialogues = new List<Dialogue>
            {
                new Dialogue
                {
                    Id = 1,
                    Messages = "Bonjour Detective.;The name is Hercule Poirot.;It is a pleasure to meet you."
                },
                new Dialogue
                {
                    Id = 2,
                    Messages = "Hi"
                },
            };

            context.Games.Add(game);
            context.Dialogues.AddRange(dialogues);
            await context.SaveChangesAsync();

            game.Characters = new List<Character>
            {
                new Character
                {
                    GameId = game.Id,
                    Name = "Lieutenant Morris",
                    ResourceUrl = "games/the_orient_express/lieutenant_morris.png",
                    CharacterDialogues = new List<CharacterDialogue>
                    {
                        new CharacterDialogue
                        {
                            DialogueId = 2,
                            CharacterStage = 0,
                        }
                    }
                }
            };

            game.GameDialogues = new List<GameDialogue>
            {
                new GameDialogue
                {
                    DialogueId = 1,
                    GameId = game.Id,
                    GameStage = 0,
                    GameDialogueActions = new List<GameDialogueAction>
                    {
                        new GameDialogueAction
                        {
                            Action = "The pleasure is all mine.What has happened?",
                            NextGameStage = 1
                        }
                    }
                }
            };
            game.Hints = new List<Hint>
            {
                new Hint
                {
                    GameId = game.Id,
                    GameStage = 1,
                    Information = "That's it folks"
                }
            };

            context.Games.Update(game);
            await context.SaveChangesAsync();
        }
    }
}

