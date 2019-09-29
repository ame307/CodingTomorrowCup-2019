using Coding_Tomorrow_Cup_Qualifier1.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Routing
    {
        private static Routing instance;
        public static Routing GetInstance()
        {
            if (instance == null)
            {
                instance = new Routing();
            }

            return instance;
        }

        private Car myCar;

        public Car MyCar
        {
            set { myCar = value; }
        }

        private List<Car> cars;

        public List<Car> Cars
        {
            set { cars = value; }
        }

        private List<string> turnCommands;

        public void SetTurnCommands()
        {
            turnCommands = TurnToStartDirection(GetCarDirection(), PathDirection());
        }

        private static string[] defaultmap = new string[]
            {
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "PPSSPPPZZPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPZZPPPSSPP",
                "GPSSPGPSSPGBBGBBGGBBGGBBGBBGPSSPGBBGBBGGBBGGBBGBBGPSSPBPSSPG",
                "GPSSPBPSSPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPBPSSPG",
                "GPSSPBPSSPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPGPSSSSPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPSSSSSPGBPSSPGTGPSPPPPPPSSSSSSSSSPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPSSSSSSPGPSSPGGGPSSSSSSSSSSSSSSSSPSPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPSSSSSPPPSSPPBBPSSSSSSSSSSPPSSSSSSPSPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPSSSSSSSSSSSPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSSGPSSPG",
                "GPSSPGGGGPSSSSSSBBSSSSSSSSSSPPSSSSSSPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPSSSSSBBSSSSSSSSSSPPSPPPPSSSPPSSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPSSSSSPPPPPPPPPPPSPPSSSSSSPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSSPPSSSSPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPSSSSSPGPPSSSSSSSTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSSPPSSSSSPSSSSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPSPGGPSSSSSSSSSSSPPSSSSPSSSSPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPSSSSPPSSSSSSSSPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPSSSSSPPSSSSSPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPSSSSSPPPPSSSPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPSSSSSSSPSSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPSSSSSPPSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPSSSSPGGGPSPPPSPPSPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPSPPSPPPSSSSSPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPSSPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSSSSPBBBBPSSSSPGGPSPPPSSPPPPPGGPSSSSPGBBPSSSSPGPSSPG",
                "GPSSPBSSSSSSPBBBBPSSSSPBBPSSSSSSSSSSSGGSSSSSPGBBGPSSPGBPSSPG",
                "GPSSPBPPSSSSPGGGGPSSSSPGGPSSSSSSSSSSPGGPSSSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPSSPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGPSPPSSPPPPPPZZPPPPPPZZPPPPPPSSPPPPPPZZPPPPPPZZSPGPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPGPSSPPPPPSSPPPPPPPPPPPPZZPPPPPZZPPPPPSSPPPPPSSPPPBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPGPSSPPPPPZZPPPPPPPPPPPPSSPPPPPSSPPPPPSSPPPPPSSPPGGPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSGBPSSPG",
                "GPSSPGSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPPSSPPPPZZPPPPSSPPPPZZPPPPSSPPPPPPPPPPSSPPPPZZPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPGBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPBBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPPPPSSPPPPZZPPPPSSPPPPZZPPPPPPPPPPZZPPPPSSPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGPSSPG",
                "GPSSPGGSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGGGPSSPG",
                "GPSSPGGPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPGGGGPSSPG",
                "GPSSPGGGGGGGGGGGGGBBBBGGBBBBPSSPBBBBGGBBBBGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG"
            };
        private static string[] map = defaultmap;
        private List<Location> route;


        public Routing FindRoute(int StartX, int StartY, int TargetX, int TargetY, Car car)
        {
            this.myCar = car;
            Location current = null;
            var start = new Location { X = StartX, Y = StartY };
            var target = new Location { X = TargetX, Y = TargetY };
            var openList = new List<Location>();
            var closedList = new List<Location>();
            int currentDistanceFromStart = 0;

            route = new List<Location>();
            target = CheckRoad(target.X, target.Y, map);

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowest = openList.Min(l => l.distanceScore);
                current = openList.First(l => l.distanceScore == lowest);
                closedList.Add(current);
                openList.Remove(current);

                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;

                var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, map, car);
                currentDistanceFromStart++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) != null)
                        continue;

                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) == null)
                    {

                        adjacentSquare.distanceFromStart = currentDistanceFromStart;
                        adjacentSquare.distanceFromTarget = ComputeEndDistance(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.distanceScore = adjacentSquare.distanceFromStart + adjacentSquare.distanceFromTarget;
                        adjacentSquare.previousLocation = current;
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if (currentDistanceFromStart + adjacentSquare.distanceFromTarget > adjacentSquare.distanceScore)
                        {
                            adjacentSquare.distanceFromStart = currentDistanceFromStart;
                            adjacentSquare.distanceScore = adjacentSquare.distanceFromStart + adjacentSquare.distanceFromTarget;
                            adjacentSquare.previousLocation = current;
                        }
                    }
                }
            }

            while (current != null)
            {
                this.route.Add(new Location { X = current.X, Y = current.Y });
                current = current.previousLocation;
            }

            this.route.Reverse();
            return this;
        }

        private string GetCarDirection()
        {
            string direction = null;

            switch (this.myCar.Direction)
            {
                case "UP": direction = global::Direction.NORTH.ToString(); break;
                case "DOWN": direction = global::Direction.SOUTH.ToString(); break;
                case "LEFT": direction = global::Direction.WEST.ToString(); break;
                case "RIGHT": direction = global::Direction.EAST.ToString(); break;
            }

            return direction;
        }

        private List<Location> GetWalkableAdjacentSquares(int x, int y, string[] map, Car car)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };

            if (proposedLocations[0].Y == -1)
                proposedLocations[0] = new Location { X = x, Y = 59 };
            if (proposedLocations[1].Y == 60)
                proposedLocations[1] = new Location { X = x, Y = 0 };
            if (proposedLocations[2].X == -1)
                proposedLocations[2] = new Location { X = 59, Y = y };
            if (proposedLocations[3].X == 60)
                proposedLocations[3] = new Location { X = 0, Y = y };

            Pos jarda = new Pos(0, 0);
            Pos jarda2 = new Pos(0, 0);
            Pos korforgalom = new Pos(0, 0);

            //switch (car.Direction)
            //{
            //    case "UP":
            //        jarda.PosX = car.Position.PosX + 1; jarda.PosY = car.Position.PosY;
            //        jarda2.PosX = car.Position.PosX + 1; jarda2.PosY = car.Position.PosY + 1;
            //        korforgalom.PosX = car.Position.PosX - 1; jarda.PosY = car.Position.PosY;
            //        break;
            //    case "DOWN":
            //        jarda.PosX = car.Position.PosX - 1; jarda.PosY = car.Position.PosY;
            //        jarda2.PosX = car.Position.PosX - 1; jarda2.PosY = car.Position.PosY - 1;
            //        korforgalom.PosX = car.Position.PosX + 1; jarda.PosY = car.Position.PosY;
            //        break;
            //    case "LEFT":
            //        jarda.PosX = car.Position.PosX; jarda.PosY = car.Position.PosY - 1;
            //        jarda2.PosX = car.Position.PosX + 1; jarda2.PosY = car.Position.PosY - 1;
            //        korforgalom.PosX = car.Position.PosX - 1; jarda.PosY = car.Position.PosY;
            //        break;
            //    case "RIGHT":
            //        jarda.PosX = car.Position.PosX; jarda.PosY = car.Position.PosY + 1;
            //        jarda2.PosX = car.Position.PosX - 1; jarda2.PosY = car.Position.PosY + 1;
            //        korforgalom.PosX = car.Position.PosX + 1; jarda.PosY = car.Position.PosY;
            //        break;
            //}

            //foreach (Location l in proposedLocations)
            //{
            //    if ()
            //}


            return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z').ToList();
        }

        private Location CheckRoad(int x, int y, string[] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
                new Location { X = x, Y = y }
            };

            if (proposedLocations[1].Y == -1)
                proposedLocations[1] = new Location { X = x, Y = 59 };
            if (proposedLocations[2].Y == 60)
                proposedLocations[2] = new Location { X = x, Y = 0 };
            if (proposedLocations[3].X == -1)
                proposedLocations[3] = new Location { X = 59, Y = y };
            if (proposedLocations[4].X == 60)
                proposedLocations[4] = new Location { X = 0, Y = y };

            return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z').ToList()[0];
        }

        static int ComputeEndDistance(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }

        public List<Pos> ToPositions()
        {
            List<Pos> positions = new List<Pos>();
            for (int i = 0; i < this.route.Count; i++)
                positions.Add(new Pos(this.route[i].X, this.route[i].Y));

            return positions;
        }

        public string ToCommand()
        {
            List<string> directions = new List<string>();
            string direction = PathDirection();

            int i = 1;
            while (i < route.Count)
            {
                if (this.route[i - 1].X != this.route[i].X && (direction == Direction.NORTH.ToString() || direction == Direction.SOUTH.ToString()))
                {
                    if (this.route[i - 1].X < this.route[i].X)
                    {
                        directions.Add(direction == Direction.SOUTH.ToString() ? "LEFT" : "RIGHT");
                        direction = Direction.EAST.ToString();
                    }
                    else
                    {
                        directions.Add(direction == Direction.NORTH.ToString() ? "LEFT" : "RIGHT");
                        direction = Direction.WEST.ToString();
                    }
                }
                else if (this.route[i - 1].Y != this.route[i].Y && (direction == Direction.WEST.ToString() || direction == Direction.EAST.ToString()))
                {
                    if (this.route[i - 1].Y < this.route[i].Y)
                    {
                        directions.Add(direction == Direction.EAST.ToString() ? "RIGHT" : "LEFT");
                        direction = Direction.SOUTH.ToString();
                    }
                    else
                    {
                        directions.Add(direction == Direction.WEST.ToString() ? "RIGHT" : "LEFT");
                        direction = Direction.NORTH.ToString();
                    }
                }
                else
                {
                    directions.Add("FORWARD");
                    i++;
                }
            }
            return CreateCommand(directions);
        }

        private string PathDirection()
        {
            string direction = null;

            if (this.route.Count == 1) { }
            else if (this.route[0].X - this.route[1].X == 0)
                direction = this.route[0].Y < this.route[1].Y ? Direction.SOUTH.ToString() : Direction.NORTH.ToString();
            else
                direction = this.route[0].X < this.route[1].X ? Direction.EAST.ToString() : Direction.WEST.ToString();

            return direction;
        }

        private string CreateCommand(List<string> directions)
        {

            directions = CountForwards(directions);
            int speed = this.myCar.Speed;
            int hp = this.myCar.Life;
            string command;
            string direction;

            if (DoWeTurnAtStart())
            {
                command = TurnAtStart();
            }
            else if (DoWeGivePriority())
            {
                command = GivePriority();
            }
            else if (DoWeDecelerate(directions[0], speed))
            {
                command = Decelerate();
            }
            else if (DoWeTurn(directions, speed, out direction))
            {
                command = Turn(direction);
            }
            else if (DoWeAccelerate(directions[0],speed))
            {
                command = Accelerate();
            }  
            else
            {
                command = DoNothing();
            }

            return command;

        }

        private bool DoWeTurnAtStart()
        {
            if (this.turnCommands.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string TurnAtStart()
        {
            string command = this.turnCommands[0];
            this.turnCommands.RemoveAt(0);

            return command;
        }

        private bool DoWeGivePriority()
        {
            return false;
        }

        private string GivePriority()
        {
            return null;
        }

        private bool DoWeDecelerate(string forward, int speed)
        {
            int street;
            if (int.TryParse(forward, out street))
            {
                if (speed == 0)
                    return false;
                else if (street <= 2 && speed == 1)
                    return true;
                else if (street <= 4 && speed == 2)
                    return true;
                else if (street <= 6 && speed == 3)
                    return true;
            }
             return false;
            
        }

        private string Decelerate()
        {
            return Command.DECELERATION.ToString();
        }

        private bool DoWeTurn(List<string> directions, int speed, out string direction)
        {
            int street ;
            if(int.TryParse(directions[0], out street))
            {
                if(speed == 1 && street - 1 == 1 && directions.Count > 1)
                {
                    direction = directions[1];
                    return true;
                }
                else
                {
                    direction = null;
                    return false;
                }
            }
            else 
            {
                direction = directions[0];
                return true;
            }
        }

        private string Turn(string direction)
        {
            if (direction == "LEFT")
            {
                return Command.CAR_INDEX_LEFT.ToString();
            }
            else
            {
                return Command.CAR_INDEX_RIGHT.ToString();
            }
        }

        private bool DoWeAccelerate(string forward, int speed)
        {
            int street;
            if (int.TryParse(forward, out street))
            {
                if (street >= 0 && speed == 0)
                    return true;
                else if (street >= 4 && speed == 1)
                    return true;
                else if (street >= 6 && speed == 2)
                    return true;
            }
            return false;
        }

        private string Accelerate()
        {
            return Command.ACCELERATION.ToString();
        }

        private string DoNothing()
        {
            return Command.NO_OP.ToString();
        }

        private List<string> TurnToStartDirection(string actualDirecton, string startDirection)
        {
            List<string> commands = new List<string>();

            if (actualDirecton == "SOUTH" && startDirection == "NORTH" ||
                actualDirecton == "NORTH" && startDirection == "SOUTH" ||
                actualDirecton == "EAST" && startDirection == "WEST" ||
                actualDirecton == "WEST" && startDirection == "EAST")
            {
                commands.Add("CAR_INDEX_LEFT");
                commands.Add("CAR_INDEX_LEFT");
            }
            else if (actualDirecton == "SOUTH" && startDirection == "WEST" ||
                     actualDirecton == "WEST" && startDirection == "NORTH" ||
                     actualDirecton == "NORTH" && startDirection == "EAST" ||
                     actualDirecton == "EAST" && startDirection == "SOUTH")
            {
                commands.Add("CAR_INDEX_RIGHT");
            }
            else if (actualDirecton == "SOUTH" && startDirection == "EAST" ||
                     actualDirecton == "EAST" && startDirection == "NORTH" ||
                     actualDirecton == "NORTH" && startDirection == "WEST" ||
                     actualDirecton == "WEST" && startDirection == "SOUTH")
            {
                commands.Add("CAR_INDEX_LEFT");
            }

            return commands;
        }

        public List<string> CountForwards(List<string> directions)
        {
            List<string> temp = new List<string>();
            int c;

            for (int i = 0; i < directions.Count; i++)
            {
                if (directions[i] == "FORWARD")
                {
                    c = 0;
                    while (i < directions.Count && directions[i] == "FORWARD")
                    {
                        c++;
                        i++;
                    }

                    temp.Add(c.ToString());
                }

                if (i < directions.Count)
                {
                    temp.Add(directions[i]);
                }
            }

            return temp;
        }

        public void ChangeMap(List<Car> cars, List<Pedestrian> pedestrians)
        {
            map = new string[]
            {
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "PPSSPPPZZPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPZZPPPSSPP",
                "GPSSPGPSSPGBBGBBGGBBGGBBGBBGPSSPGBBGBBGGBBGGBBGBBGPSSPBPSSPG",
                "GPSSPBPSSPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPBPSSPG",
                "GPSSPBPSSPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPGPSSSSPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPSSSSSPGBPSSPGTGPSPPPPPPSSSSSSSSSPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPSSSSSSPGPSSPGGGPSSSSSSSSSSSSSSSSPSPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPSSSSSPPPSSPPBBPSSSSSSSSSSPPSSSSSSPSPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPSSSSSSSSSSSPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSSGPSSPG",
                "GPSSPGGGGPSSSSSSBBSSSSSSSSSSPPSSSSSSPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPSSSSSBBSSSSSSSSSSPPSPPPPSSSPPSSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPSSSSSPPPPPPPPPPPSPPSSSSSSPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSSPPSSSSPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPSSSSSPGPPSSSSSSSTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSSPPSSSSSPSSSSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPSPGGPSSSSSSSSSSSPPSSSSPSSSSPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPSSSSPPSSSSSSSSPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPSSSSSPPSSSSSPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPSSSSSPPPPSSSPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPSSSSSSSPSSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPSSSSSPPSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPSSSSPGGGPSPPPSPPSPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPSPPSPPPSSSSSPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPSSPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSSSSPBBBBPSSSSPGGPSPPPSSPPPPPGGPSSSSPGBBPSSSSPGPSSPG",
                "GPSSPBSSSSSSPBBBBPSSSSPBBPSSSSSSSSSSSGGSSSSSPGBBGPSSPGBPSSPG",
                "GPSSPBPPSSSSPGGGGPSSSSPGGPSSSSSSSSSSPGGPSSSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPSSPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGPSPPSSPPPPPPZZPPPPPPZZPPPPPPSSPPPPPPZZPPPPPPZZSPGPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPGPSSPPPPPSSPPPPPPPPPPPPZZPPPPPZZPPPPPSSPPPPPSSPPPBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPGPSSPPPPPZZPPPPPPPPPPPPSSPPPPPSSPPPPPSSPPPPPSSPPGGPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSGBPSSPG",
                "GPSSPGSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPPSSPPPPZZPPPPSSPPPPZZPPPPSSPPPPPPPPPPSSPPPPZZPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPGBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPBBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPPPPSSPPPPZZPPPPSSPPPPZZPPPPPPPPPPZZPPPPSSPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGPSSPG",
                "GPSSPGGSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGGGPSSPG",
                "GPSSPGGPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPGGGGPSSPG",
                "GPSSPGGGGGGGGGGGGGBBBBGGBBBBPSSPBBBBGGBBBBGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG"
            };
            foreach (var car in cars)
            {
                int X = car.Position.PosX;
                int Y = car.Position.PosY;
                StringBuilder strB = new StringBuilder(map[Y]);
                strB[X] = 'C';
                map[Y] = strB.ToString();
            }
            foreach (var p in pedestrians)
            {
                int X = p.Position.PosX;
                int Y = p.Position.PosY;
                StringBuilder strB = new StringBuilder(map[Y]);
                strB[X] = 'H';
                map[Y] = strB.ToString();
            }
        }
    }
}
