using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ONyR_client.view;
using ONyR_client.model;

namespace ONyR_client.control.business
{
    public enum ErrorCode
    {
        NonONyRError=-1,
        DatabaseError,
        NoSessionError,
        InvalidSessionError,
        UnknownError,
        ModifyConflict,
        InvalidCredentialsError
    }

    public class Delegate<N>
    {
        protected N mResponder;

        public Notifier Initiator;

        public Delegate(Notifier pInitiator, N pResponder)
        {
            mResponder = pResponder;
            Initiator = pInitiator;
        }
    }

    public class Responder
    {
        public Notifier Initiator;
    }

    public class ApplicationFaultManager
    {
        public static void Fault(ErrorCode pCode, Notifier initiator)
        {
            string message = "";
            MessageBoxButtons btns = MessageBoxButtons.OK;

            switch (pCode)
            {
                case ErrorCode.DatabaseError:
                    message = "Hiba történt az adatbázissal!\nKérjük próbálkozzon újra később!";
                    btns = MessageBoxButtons.RetryCancel;
                    break;
                case ErrorCode.InvalidCredentialsError:
                    message = "A beírt felhasználónév, vagy jelszó hibás!\nKérjük ellenőrizze, hogy helyesen írta-e be őket!";
                    break;
                case ErrorCode.InvalidSessionError:
                    message = "Az ön munkamenete 30 perc tétlenség után lejárt!\nKérjük érvényesítse munkamenetét!";
                    ModelLocator.getInstance().SessionModel.Logout();
                    break;
                case ErrorCode.ModifyConflict:
                    message = "Úgy tűnik a módosítani kívánt adatok közül valamelyet már mások módosították. Kattintson az Ok gombra, ha felülírja saját módosításaival, a mégse gombra, hogyha frissíteni kívánja az adatokat!";
                    btns = MessageBoxButtons.OKCancel;
                    break;
                case ErrorCode.NonONyRError:
                    message = "A rendszertől független hiba történt!\nKérjük próbálkozzon újra később!";
                    btns = MessageBoxButtons.RetryCancel;
                    break;
                case ErrorCode.NoSessionError:
                    message = "A következő művelethez be kell jelentkeznie!";
                    ModelLocator.getInstance().SessionModel.Logout();
                    break;
                case ErrorCode.UnknownError:
                    message = "Ismeretlen hiba történt!\nKérjük próbálkozzon újra később!";
                    btns = MessageBoxButtons.RetryCancel;
                    break;
            }

            DialogResult result = MessageBox.Show(message, "Hiba", btns);

            if (result == DialogResult.Retry || pCode == ErrorCode.ModifyConflict && result == DialogResult.OK)
            {
                Notifier retryNotifier = initiator.getClone();
                retryNotifier.isForced = true;
                retryNotifier.Handle();
            }
        }
    }
}
