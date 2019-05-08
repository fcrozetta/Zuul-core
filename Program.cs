using System;
using tui_netcore;
using Zuul_Items;
using Zuul_Item_Behavior;
using Zuul_Stage;

namespace zuul_core
{
    class Program
    {

        // Command parser
        static CMD cmd = new CMD();
        // Player
        static Stage currentStage = new Stage0().create();


        static void Main(string[] args)
        {
            // ! Window Configuration

            // TODO: Find a more elegant way to define the window size and position
            Tui MainWindow = new Tui()
            {
                Title = "Detective Zuul"
            };
            Tui prompt = new Tui(Console.WindowWidth, 10, 0, Console.WindowHeight - 10)
            {
                Title = "Your Actions",
                Body = ""
            };
            Tui helpMenu = new Tui(Console.WindowWidth / 2, Console.WindowHeight / 2, 2, 2)
            {
                Title = "Help",
                Body = "Here we will have a tutorial about how to play this game, soon..."
            };
            Tui errorWindow = new Tui(Console.WindowWidth - (Console.WindowWidth / 2), 5, Console.WindowWidth / 2 - (Console.WindowWidth / 4), (Console.WindowHeight / 2) - (Console.WindowHeight / 4));
            Tui compassWindow = new Tui(18, 5, Console.WindowWidth - 20, 1) { MarginLeft = 1 };
            Tui bagWindow = new Tui(50, Console.WindowHeight - 20, 2, 2);
            // TODO: Fix the size of the window... fullscreen in ugly for an info box
            Tui infoWindow = new Tui();

            // command history
            string history = "";
            prompt.Body = cmd.showAll();


            currentStage.Player = currentStage.Player;

            while (true)
            {
                MainWindow.Body = currentStage.getCurrentWallView();
                MainWindow.Draw();

                // Draw Compass
                Item tmp = currentStage.Player.Bag.getItemByName("Compass");
                if (currentStage.Player.Bag.getItemByName("Compass") != null && (currentStage.Player.Bag.getItemByName("Compass") as Compass).IsOpen)
                {
                    (currentStage.Player.Bag.getItemByName("compass") as Compass).updateCompass(currentStage.Player.FacingSide);
                    compassWindow.Body = (currentStage.Player.Bag.getItemByName("compass") as Compass).getCompass();
                    compassWindow.Draw();
                }
                // draw bag
                if (currentStage.Player.Bag.IsOpen)
                {
                    bagWindow.Title = "Bag";
                    bagWindow.Body = currentStage.Player.Bag.getAllItems();
                    bagWindow.Draw();
                }
                string userInput = "";
                while (String.IsNullOrEmpty(userInput))
                {
                    userInput = prompt.DrawInput();
                }
                string[] command = cmd.parse(userInput);
                history += $"\n{userInput}";

                var execution = executeCommand(command);

                // Logic to draw the windows
                // this switch must stay here, because the console in attached to the main function
                switch (execution.status)
                {
                    // everything is okay. nothing is shown
                    case 0:
                        break;
                    case 1:
                        infoWindow.Title = "Info";
                        infoWindow.Body = execution.mesage;
                        infoWindow.DrawOk(Tui.ColorSchema.Info);
                        break;
                    // Help Menu
                    case 9:
                        helpMenu.DrawOk(Tui.ColorSchema.Info);
                        break;
                    default:
                        errorWindow.Body = execution.mesage;
                        errorWindow.DrawOk(Tui.ColorSchema.Danger);
                        break;

                }
            }
        }

        // Logic to execute the command
        static (int status, string mesage) executeCommand(string[] command)
        {
            switch (command[0])
            {
                // TODO: Implement actions
                case "int":
                    return interactCommand(command);
                case "bag":
                    currentStage.Player.Bag.IsOpen = !currentStage.Player.Bag.IsOpen;
                    return (0, "bag");
                case "examine":
                    return examineCommand(command);
                case "pick":
                    return pickCommand(command);
                case "look":
                    return lookCommand(command);
                case "use":
                    return useCommand(command);

                case "help":
                    return (9, "Help Menu");
                case "quit":
                    Environment.Exit(0);
                    return (-9, "Quit game");
                default:
                    return (-1, "Invalid command");
            }
        }

        static (int status, string message) useCommand(string[] tokens)
        {

            return currentStage.useItem(tokens[1]);
        }
        static (int status, string message) lookCommand(string[] tokens)
        {
            // you can write the full direction, but will take only the first char
            currentStage.Player.turn(tokens[1].ToCharArray()[0]);
            return (0, $"plyer turned {tokens[1]}");
        }

        static (int status, string message) pickCommand(string[] tokens)
        {
            if (currentStage.playerPick(tokens[1]))
            {
                return (0, "item picked");
            }
            return (-1, "Can't pick it up");
        }
        static (int status, string message) examineCommand(string[] tokens)
        {
            Item item = currentStage.Player.Bag.getItemByName(tokens[1]);
            if (item != null)
            {
                return (1, item.Description);
            }
            else
            {
                return (-1, "You don't have this item in your bag");
            }
        }
        static (int status, string message) interactCommand(string[] tokens)
        {
            Item item = currentStage.Player.Bag.getItemByName(tokens[1]);
            if (item == null)
            {
                return (-1, $"You don't have this Item in your bag");
            }
            else
            {
                if (item is IInteractable && (item as IInteractable).IsInteractable)
                {
                    return (item as IInteractable).interact();
                }
                else
                {
                    return (-1, "You cannot interact with the item right now");
                }
            }
        }
    }
}
