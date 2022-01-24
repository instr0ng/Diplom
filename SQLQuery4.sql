--select coalesce(name + ' ' + DeviceVersionStr, name) as NameDevice, DeviceType, pd.protocol_id, ifp.interface_id from dTypesElement dt left join protocoldevices pd on dt.DeviceType = pd.device_type_id left join interfaceprotocol ifp on pd.protocol_id = ifp.protocol_id where ElementType = 4 order by DeviceType
select b.Id, coalesce(b.name + ' ' + b.DeviceVersionStr, b.name), b.DeviceType, b.DeviceVersion, a.protocol_id, v.interface_id from dTypesElement b
left join protocoldevices a on (a.device_type_id=b.Id)
inner join interfaceprotocol v on(v.protocol_id=a.protocol_id) 
where elementtype=4 
order by b.DeviceType