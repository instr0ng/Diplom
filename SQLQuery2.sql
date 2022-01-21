--select coalesce(name + ' ' + DeviceVersionStr, name), DeviceType from dTypesElement where ElementType = 4 order by DeviceType
select b.Id, b.Name, b.DeviceType, b.DeviceVersion, a.protocol_id, v.interface_id
from protocoldevices a
inner join interfaceprotocol v on(v.protocol_id=a.protocol_id)
inner join dTypesElement b on (a.device_type_id=b.Id) and (elementtype=4)
order by b.DeviceType