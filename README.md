# 这是一个记录交易记录的小程序

1. PyWrapper，封装了tushare pro api接口
   封装该接口的原因是，tushare pro有访问次数限制，比如每分钟XX次访问。封装了之后，记录每次调用api的时间，如果每分钟调用次数达到上额，则等待X秒钟。
2. NetTrading，这是执行网格交易的工程
