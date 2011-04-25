using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONyR_client.model.vo
{
    class UserVO : UserServiceSkeleton.UserVO, IValueObject<UserVO>
    {
        public UserVO Clone()
        {
            return new UserVO().FillFromSkeleton(this);
        }

        public UserVO FillFromSkeleton(object pSkeleton)
        {
            UserServiceSkeleton.UserVO other = (UserServiceSkeleton.UserVO)pSkeleton;

            ID = other.ID;
            Name = other.Name;
            UserName = other.UserName;

            return this;
        }
    }
}
