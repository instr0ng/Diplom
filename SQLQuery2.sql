--select coalesce(name + ' ' + DeviceVersionStr, name), DeviceType from dTypesElement where ElementType = 4 order by DeviceType
select coalesce(b.name + ' ' + b.DeviceVersionStr, b.name) as dev
from protocoldevices a
inner join interfaceprotocol v on(v.protocol_id=a.protocol_id)
inner join dTypesElement b on (a.device_type_id=b.Id) and (elementtype=4) and v.interface_id = (select PortType from ComPorts where ID = 1)
