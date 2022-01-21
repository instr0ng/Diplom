﻿select coalesce(name + ' ' + DeviceVersionStr, name), DeviceType, pd.device_type_id, pd.protocol_id from dTypesElement dt left join protocoldevices pd on dt.DeviceType = pd.device_type_id where ElementType = 4 order by DeviceType