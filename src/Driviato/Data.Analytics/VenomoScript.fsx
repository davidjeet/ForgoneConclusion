
#r "C:\Users\jamie\Desktop\4Gone.DriveSafe.Analytics\packages\VenmoWrapper.1.0.1.0\lib\portable-win+net40+sl50+wp80\VenmoWrapper.dll"
#r "C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5.1/System.Net.dll"

open VenmoWrapper

let postTransaction = VenmoHelper.PostVenmoTransaction(VenmoHelper.USER_TYPE.PHONE,"9195381155","Test",10.)


//a36fd20c74379b95c43d270adf5620b9ea7735a31adbf97fb791e9e21ca5bfec
