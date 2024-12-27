import pandas as pd
import tushare as ts

def __init__():
    ts.pro_api("08137b71632f695b667fd2f45f0f9b5bde7cccf0619aca99c1677d3e");

def query_price(codes):

    try:
        return ts.realtime_quote(ts_code = codes, src='sina')
    except Exception:
        try:
            return ts.realtime_quote(ts_code=codes, src='dc')
        except Exception:
            return None
        
def test_get_dataframe():
    data = {'Column1': [1, 2, 3, 4],
            'Column2': ['A', 'B', 'C', 'D']}
    df = pd.DataFrame(data)
    return df

def test_runtime_quote(code):
    df = ts.realtime_quote(ts_code = code) #'600000.SH,000001.SZ,000001.SH')
    return df
