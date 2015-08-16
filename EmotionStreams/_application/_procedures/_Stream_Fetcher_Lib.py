# -*- coding: utf-8 -*-
#! imports

#! request
import requests


class Stream_Fetcher_Lib():

    def __init__(self, _url, _stream):
        self.STREAM = str(_stream)
        self.URL = _url

    def Post__(self):
        _request = requests.post(self.URL, self.STREAM, timeout=30000)
        return eval(_request.text)

    def Get__(self):
        _url = self.URL + self.STREAM[0]['text']
        _request = requests.get(str(_url), timeout=30000)
        return eval(_request.text)
