using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Matthew Harrand
    // Dated Created: 1/22/2020
    // Last Modified: 1/25/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void DisplaySetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();
            DisplaySetTheme();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) TalentShowBustAMove ");
                Console.WriteLine("\tc) ");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowBustAMove(finchRobot);
                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Bust a Move                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowBustAMove(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Bust A move");

            Console.WriteLine("\tThe Finch robot will now show off its cool moves!");
            finchRobot.setMotors(-255, 69);
            finchRobot.setMotors(100, -100);
            finchRobot.setMotors(255, -255);
            DisplayContinuePrompt();
        }



        #endregion

        #region DATA RECORDER
       static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            bool Valid = false;
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu= false;
            string menuChoice;

            

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) show Data");
                Console.WriteLine("\te) ");
                Console.WriteLine("\tf) ");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberofDataPoints(Valid);
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency(Valid);
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData( numberOfDataPoints,dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayTable(temperatures);
                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }





        static void DataRecorderDisplayTable(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");
            //
            // display table
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
                "----------".PadLeft(15) +
                "----------".PadLeft(15)
                );

            //
            // display table data
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                                (index + 1).ToString().PadLeft(15) +
                                temperatures[index].ToString().PadLeft(15)
                                );
            }
            DisplayContinuePrompt();
        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {

            double[] temperatures = new double[numberOfDataPoints];
            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of data points: {numberOfDataPoints}");
            Console.WriteLine($"Data point frequency {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("The finch is ready to begin recording temperature data");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1} {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }
                DisplayContinuePrompt();

                return temperatures;
            
        }


         static double DataRecorderDisplayGetDataPointFrequency(bool Valid)
        {
            double dataPointFrequency;
           

            DisplayScreenHeader("Data Point Frequency");

            Console.Write("\tNumber of data points: ");


            // validate input
              
            do
            {

                if (double.TryParse(Console.ReadLine(), out dataPointFrequency)) 
                {
                    Valid = true;
                }

                else
                {
                    Console.WriteLine("enter a valid datapoint");
                }
            } while (Valid !=true);
           

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        
        

        static int DataRecorderDisplayGetNumberofDataPoints(bool Valid)
        {
            int numberOfDataPoints;
            string userResponse;

            DisplayScreenHeader ("Number of Data Points");

            Console.Write("Number of data points: ");
            userResponse = Console.ReadLine();

            // validate input
            do
            {
                if (int.TryParse(userResponse, out numberOfDataPoints))
                { 
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("\tEnter a valid data point");
                    userResponse = Console.ReadLine();
                }
            } while (Valid !=true);
            

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }
        #endregion

        #region LIGHT ALARM
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;
            bool Valid = false;
            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = " ";
            string rangeType = " ";
            int minMaxthresholdValue = 0;
            int timeToMonitor = 0;



            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor " );
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold");
                Console.WriteLine("\td) Set time to monitor ");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tf) ");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor(Valid);
                        break;
                        
                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType(Valid);
                        break;

                    case "c":
                        minMaxthresholdValue = LightAlarmSetMinMaxThresholdValue(rangeType, finchRobot, Valid);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor(Valid);
                        break;

                    case "e":
                        LightAlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxthresholdValue, timeToMonitor );
                        break;

                    case "f":
                        
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

        }

         static void LightAlarmSetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxthresholdValue, int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;
            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"Sensors to monitor {sensorsToMonitor}");
            Console.WriteLine("Range Type: {0} ", rangeType);
            Console.WriteLine("Min/Mac threshold value: {0} ", minMaxthresholdValue);
            Console.WriteLine("Time to monitor: {0}", timeToMonitor);
            Console.WriteLine();

            Console.WriteLine("Pres any key to begin");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded )
            {
                switch (sensorsToMonitor)
                {
                    case "Left":
                        currentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;
                    case "Right":
                        currentLightSensorValue = finchRobot.getRightLightSensor();
                        break;
                    case "Both":
                        currentLightSensorValue = (finchRobot.getRightLightSensor() + finchRobot.getLeftLightSensor()) / 2;
                        break;
                }
                switch (rangeType)
                {
                    
                    case "minimum":
                        if (currentLightSensorValue < minMaxthresholdValue )
                        {
                            thresholdExceeded = true;
                        }

                        break;

                    case "Maximum":
                        if (currentLightSensorValue > minMaxthresholdValue)
                        {
                            thresholdExceeded = true; 
                        }
                        break;
                }
                finchRobot.wait(1000);
                

                secondsElapsed++;

            }
            if (thresholdExceeded)
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxthresholdValue} exceeded by the current light sensor value of {currentLightSensorValue}");
            }
            else
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxthresholdValue} not exceeded by the current light sensor value of {currentLightSensorValue}");
            }
            DisplayMenuPrompt("Light Alarm");
        }

        static int LightAlarmSetTimeToMonitor(bool Valid)
        {
            int timeToMonitor;

            DisplayScreenHeader("Time to monitor");

            

            // validate value

            Console.WriteLine($"\tTime to monitor");
            do
            {
                if (int.TryParse(Console.ReadLine(), out timeToMonitor))
                { 
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("\tEnter a valid time to monitor");
                }
            } while (Valid !=true);
            Valid = false;

            // echo value

            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }

        static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch finchRobot, bool Valid)
        {
            int minMaxThresholdValue;

            DisplayScreenHeader("Minimum/Maximum threshold value");

            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()} ");

            Console.WriteLine($"\tRight light sensor ambient value: {finchRobot.getRightLightSensor()} ");

            Console.WriteLine();

            // validate value

            Console.WriteLine($"Enter the {rangeType} light sensor value:");
            do
            {
                if (int.TryParse(Console.ReadLine(), out minMaxThresholdValue))
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("\tEnter in a valid number");
                }
            } while (Valid !=true);
            Valid = false;

            // echo value

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }

        static string LightAlarmDisplaySetSensorsToMonitor(bool Valid)
        {
            string sensorsToMonitor;
            DisplayScreenHeader("Sensors to monitor");
            Console.WriteLine("Sensors to monitor [Left, right, both]");
            sensorsToMonitor = Console.ReadLine();
            //
            //put error checking
            //

            do
            {
                
                if ( sensorsToMonitor == "Left" || sensorsToMonitor == "right" || sensorsToMonitor == "both") 
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("Enter left, right, or both");
                    sensorsToMonitor = Console.ReadLine().ToLower();
                }
            } while (Valid !=true);
            Valid = false;

            DisplayMenuPrompt("Light Alarm");


            return sensorsToMonitor;
        }

        static string LightAlarmDisplaySetRangeType(bool Valid)
        {
            string rangeType;
            DisplayScreenHeader("rangeType");
            Console.WriteLine("\tRange Type [minimum, maximum");

            
                      
            rangeType = Console.ReadLine().ToLower();

            do
            {
                if (rangeType == "minimum" || rangeType == "maximum")
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("Enter minimum or maximum");
                }
            } while (Valid != true);
            Valid = false;

            DisplayMenuPrompt("Light Alarm");


            return rangeType;
        }


        #endregion

        #region USER PROGRAMMING
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            string menuChoice;
            bool quitMenu = false;

            //
            // tuples to store command parameters
            //
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();


            do
            {
                DisplayScreenHeader("User programming menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta Set Command parameters ");
                Console.WriteLine("\tb) add commands");
                Console.WriteLine("\tc) view commands");
                Console.WriteLine("\td) Set time to monitor ");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tf) ");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                         UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        DisplayExecuteFinchCommands(finchRobot,commands, commandParameters );
                        break;

                    case "e":
                        
                        break;

                    case "f":
                        
                        break;

                    case "q":
                        
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

        }

        private static void DisplayExecuteFinchCommands(Finch finchRobot, List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMiliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute finch commands");

            Console.WriteLine("\tThe finch robot is ready to execute the list of commands");
            DisplayContinuePrompt();
            foreach (Command  command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitMiliSeconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;
                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        commandFeedback = $"Temperature: {finchRobot.getTemperature().ToString("n2")}\n";
                        break;

                    case Command.DONE:
                        commandFeedback = Command.DONE.ToString();
                        break;

                }
                Console.WriteLine($"\t{commandFeedback}");
            }
            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Display finch commands");
            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }
            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch robot commands");

            //
            // List commands
            //

            int commandCount = 1;
            Console.WriteLine("\tList of Available commands");
            Console.WriteLine();
            Console.WriteLine("\t-");
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"- {commandName.ToLower()} -");
                if (commandCount % 5 == 0) Console.WriteLine("-\n\t-");
                commandCount++;
            }
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.Write("\tEnter Command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\tEnter a valid command from the list above");
                }
            }

            DisplayMenuPrompt("User Programming");
        }

        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            DisplayScreenHeader("Command Parameters");
            Console.WriteLine ("\tEnter Motor speed [1 - 255]: ", 1, 255);
            commandParameters.motorSpeed = Convert.ToInt32(Console.ReadLine());
            if (commandParameters.motorSpeed > 255 || commandParameters.motorSpeed < 1)
            {
                Console.WriteLine("Enter a number from 1 - 255 please");
            }

            Console.WriteLine("\tEnter LED brightness [1 - 255]: ", 1, 255);
            commandParameters.ledBrightness = Convert.ToInt32(Console.ReadLine());
            if (commandParameters.ledBrightness > -255 || commandParameters.ledBrightness < 1)
            {
                Console.WriteLine("Enter a number from 1 - 255 please");
            }

            Console.WriteLine("\tEnter wait in seconds: ", 0, 10);
            commandParameters.waitSeconds = Convert.ToDouble(Console.ReadLine());
             

            Console.WriteLine();
            Console.WriteLine($"\tMotor speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLED brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait command duration: {commandParameters.waitSeconds}");

            DisplayMenuPrompt("User Programming");

            return commandParameters;

           

        }

            #endregion

        #region FINCH ROBOT MANAGEMENT

            /// <summary>
            /// *****************************************************************
            /// *               Disconnect the Finch Robot                      *
            /// *****************************************************************
            /// </summary>
            /// <param name="finchRobot">finch robot object</param>
            static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion

        
    }

}
