using System.Collections.Generic;

namespace ElevatorControl
{
    /// <summary>
    /// IState interface describes an interface for state management of 
    /// and elevator
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Gets the current work queue
        /// </summary>
        /// <returns>IEnumerable of Floors the elevator is servicing</returns>
        public IEnumerable<Floor> GetWorkQueue();

        /// <summary>
        /// Adds a floor to the elevators work queue
        /// </summary>
        /// <param name="floor">the floor to add</param>
        public void AddFloor(Floor floor);

        /// <summary>
        /// Retrieves the next floor from the elevators work queue
        /// </summary>
        /// <returns>The next floor the elevator should move to</returns>
        public Floor NextFloor();
    }
}
