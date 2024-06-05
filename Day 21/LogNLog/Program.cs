using System;
using NLog;
using NLog.Config;

class Program{
    public static Logger logger = LogManager.GetCurrentClassLogger();
    static void Main(){
        // Access NLOG Class
        LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");

        logger.Debug("Starting Robot");
        Robot robot = new Robot();
        logger.Info("Starting Walk");
        robot.Walk();
        logger.Info("Program Finished");
}


class Robot{
    public void Walk(){
        // Main Walk
        logger.Info("Prepare to Walk 1 Steps");
        LeftLegMove();
        RightLegMove();
        logger.Info("Have Walk 1 Steps");
    }
    private void LeftLegMove(){
        // Process
        logger.Info("Move Left Leg");

    }
    private void RightLegMove(){
        // Process
        logger.Info("Move Right Leg");
        
    }
}
}