--select dt.name from dtypesElement dt join protocoldevices pd on dt.DeviceType = pd.device_type_id join interfaceprotocol ifp on pd.protocol_id = ifp.protocol_id join comports cp on ifp.interface_id = cp.porttype group by name
--select name from dTypesElement where ElementType = 4
--select * from protocoldevices
select DeviceType, coalesce(name + ' ' + DeviceVersionStr, name) from dTypesElement dt  where ElementType = 4 order by DeviceType