using System;
using System.Collections.Generic;

namespace ONyR_client.control
{
    /// <summary>
    /// The event handler delegate, to handle notifiers.
    /// </summary>
    /// <typeparam name="N">The type of the notifier.</typeparam>
    /// <param name="pSender">The sender object.</param>
    /// <param name="pNotifier">The notifier object.</param>
    delegate void NotifierHandler<N>(object pSender, N pNotifier);

    /// <summary>
    /// The front controller class that is responsible to connect the notifiers with their corresponding commands.
    /// </summary>
    public abstract class FrontController
    {
        /// <summary>
        /// The dictionary that holds the connections between notifiers and commands
        /// </summary>
        private Dictionary<Type, Connection> mConnections;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrontController"/> class.
        /// </summary>
        public FrontController()
        {
            mConnections = new Dictionary<Type, Connection>();

            Initialize();
        }

        /// <summary>
        /// Initializes this instance. Implement this method to add the connections between notifier and command classes.
        /// </summary>
        protected abstract void Initialize();

        /// <summary>
        /// Adds the connection between the notifier and the command classes.
        /// </summary>
        /// <param name="pNotifier">The notifier type to connect to the command type.</param>
        /// <param name="pCommand">The command type to connect to the notifier tpy.</param>
        protected void addConnection(Type pNotifier, Type pCommand)
        {
            Connection connection;

            if (mConnections.ContainsKey(pNotifier))
            {
                throw new Exception(String.Format("Command for Notifier \"{0}\" was already set!", pNotifier));
            }

            try
            {
                connection = (Connection)typeof(Connection)
                    .GetMethod("GetConnection")
                    .MakeGenericMethod(new[] { pNotifier, pCommand })
                    .Invoke(null, null);
            }
            catch (Exception e)
            {
                throw new Exception("Not supported notifier/command type!", e);
            }

            mConnections[pNotifier] = connection;

            Notifier.registerFrontController(pNotifier, this);
        }

        /// <summary>
        /// Gets the corresponding connection for the notifier type.
        /// </summary>
        /// <param name="pNotifier">The type of the notifier.</param>
        /// <returns>The corresponding Connection instance.</returns>
        public Connection getConnection(Type pNotifier)
        {
            return mConnections[pNotifier];
        }
    }

    /// <summary>
    /// The class that represents the connection between a notifier and a corresponding command.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Occurs when the notification is happening.
        /// </summary>
        private event NotifierHandler<Notifier> OnNofityEvent;

        /// <summary>
        /// Called when a notification is requested.
        /// </summary>
        /// <typeparam name="N">The type of the notifier instance.</typeparam>
        /// <param name="pNotifier">The notifier instance.</param>
        public void OnNotify<N>(N pNotifier) where N : Notifier
        {
            OnNofityEvent(this, pNotifier);
        }

        /// <summary>
        /// Constructs the notification between the notification and the command type.
        /// </summary>
        /// <typeparam name="N">The type of the notification object.</typeparam>
        /// <typeparam name="C">The type of the corresponding command.</typeparam>
        /// <returns>The constructed Connection instance between the notification and the command type.</returns>
        public static Connection GetConnection<N, C>()
            where N : Notifier
            where C : ICommand<Notifier>, new()
        {
            Connection connection = new Connection();

            connection.OnNofityEvent += new NotifierHandler<Notifier>(new C().handleNotification);
            return connection;
        }
    }

    public interface ICommand<N>
    {
        void handleNotification(object pSender, N pNotifier);
    }

    /// <summary>
    /// The command class.
    /// </summary>
    /// <typeparam name="N">The type of the corresponding notification.</typeparam>
    public abstract class Command<N> : ICommand<Notifier>
        where N : Notifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command&lt;N&gt;"/> class.
        /// </summary>
        public Command() { }

        /// <summary>
        /// Handles the notification.
        /// </summary>
        /// <param name="pSender">The sender.</param>
        /// <param name="pNotifier">The notifier.</param>
        public void handleNotification(object pSender, N pNotifier)
        {
            execute(pNotifier);
        }

        /// <summary>
        /// Handles the notification.
        /// </summary>
        /// <param name="pSender">The sender.</param>
        /// <param name="pNotifier">The notifier.</param>
        public void handleNotification(object pSender, Notifier pNotifier)
        {
            execute((N)pNotifier);
        }

        /// <summary>
        /// Executes the specified notification. Override this method when using custom commands.
        /// </summary>
        /// <param name="pNotifier">The notifier.</param>
        protected abstract void execute(N pNotifier);
    }

    /// <summary>
    /// The notifier class.
    /// </summary>
    public abstract class Notifier : EventArgs, ICloneable
    {
        public bool isForced = false;

        /// <summary>
        /// Holds the front controllers for each notifier type.
        /// </summary>
        private static Dictionary<Type, FrontController> FrontControllers;

        /// <summary>
        /// Registers the front controller for the actual notifier type.
        /// </summary>
        /// <param name="pNotifier">The type of the notifier.</param>
        /// <param name="pFrontController">The front controller isntance.</param>
        public static void registerFrontController(Type pNotifier, FrontController pFrontController)
        {
            if(FrontControllers == null)
            {
                FrontControllers = new Dictionary<Type, FrontController>();
            }

            if (FrontControllers.ContainsKey(pNotifier))
            {
                throw new Exception(String.Format("FrontController for Notifier \"{0}\" was already set!", pNotifier));
            }

            FrontControllers[pNotifier] = pFrontController;
        }

        /// <summary>
        /// Handles the notification by calling the conroller to execute the corresponding command.
        /// </summary>
        public void Handle()
        {
            FrontController controller;
            Connection conntection;

            try
            {
                controller = FrontControllers[GetType()];
            }
            catch(Exception e)
            {
                throw new Exception(String.Format("FrontController for Notifier \"{0}\" isn't set!", GetType()), e);
            }

            try
            {
                 conntection = controller.getConnection(GetType());
            }
            catch(Exception e)
            {
                throw new Exception(String.Format("Connection for Notifier \"{0}\" isn't set in FrontController!", GetType()), e);
            }

            conntection.OnNotify(this);
        }

        #region ICloneable Members

        public abstract object Clone();

        #endregion

        public Notifier getClone()
        {
            return (Notifier)Clone();
        }
    }
}
