$rsa = New-Object System.Security.Cryptography.RSACryptoServiceProvider -ArgumentList 2048

$rsa.ToXmlString($true) | Out-File ./key.private.xml
$rsa.ToXmlString($false) | Out-File ./key.public.xml