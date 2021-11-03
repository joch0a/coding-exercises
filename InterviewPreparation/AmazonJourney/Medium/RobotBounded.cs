namespace InterviewPreparation.AmazonJourney.Medium
{
    public class RobotBounded
    {
        public bool IsRobotBounded(string instructions)
        {
            (int x, int y) position = (0, 0);
            (int dx, int dy) direction = (0, 1);

            for (int i = 0; i < 4; i++)
            {
                foreach (var instruction in instructions)
                {
                    switch (instruction)
                    {
                        case 'G':
                            position = (position.x + direction.dx, position.y + direction.dy);
                            break;
                        case 'L':
                            direction = (-direction.dy, direction.dx);
                            break;
                        case 'R':
                            direction = (direction.dy, -direction.dx);
                            break;
                    }
                }
            }

            return position == (0, 0) && direction == (0, 1);
        }
    }
}
