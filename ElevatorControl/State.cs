using System.Collections.Generic;
using System.Linq;

namespace ElevatorControl
{
    /// <summary>
    /// State class for an Elevator
    /// </summary>
    public class State : IState 
    {
        private Queue<Floor> _workQueue = new Queue<Floor>();

        /// <summary>
        /// Retrieves the queue of floors the elevator is servicing
        /// </summary>
        /// <returns>List of floors the elevator is servicing</returns>
        public IEnumerable<Floor> GetWorkQueue()
        {
            return _workQueue;
        }

        /// <summary>
        /// Adds a floor for the elevator to move to
        /// </summary>
        /// <param name="floor">Floor to move to</param>
        public void AddFloor(Floor floor)
        {
            if (!_workQueue.Any(x => x.Number == floor.Number))
            {
                _workQueue.Enqueue(floor);
            }
        }

        /// <summary>
        /// Retrieves the next floor for the elevator to move to
        /// </summary>
        /// <remarks>Removes the next floor from the work queue</remarks>
        /// <returns>The next floor in the queue</returns>
        public Floor NextFloor()
        {
            if (_workQueue.Any())
            {
                return _workQueue.Dequeue();
            }

            return null;
        }
    }
}
