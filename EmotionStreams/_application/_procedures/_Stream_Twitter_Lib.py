# -*- coding: utf-8 -*-
#! imports

#! libraries : birdy twitter api
from birdy.twitter import UserClient


class Stream_Twitter_Lib():

    def __init__(self):
        self.CONSUMER_KEY = 'W7e9FttyIvvksMkfVGN3GlBDl'
        self.CONSUMER_SECRET = 'JYGTf9jqOyyhyf6sn1VV9lqHKqZGF0c0tqtmsHqHv5w9l8GxTi'
        self.ACCESS_TOKEN = '388217388-CPdFmJuXF89wndHbWUJlVkBsUmSNo1SqSIohDIdI'
        self.ACCESS_TOKEN_SECRET = 'Y5sgc1axpU1Xlvw1A3pPM4QGouc4UZnAefChNJWBP6dGY'
        self.CLIENT = UserClient(self.CONSUMER_KEY,
                            self.CONSUMER_SECRET,
                            self.ACCESS_TOKEN,
                            self.ACCESS_TOKEN_SECRET)

    def Search__(self, _queries=False, _limit=False):
        _result = []
        for _query in _queries:
            response = self.CLIENT.api.search.tweets.get(q=_query, count=_limit)
            _result.append(response.data.statuses)
        return _result

    def Stream__(self, _limit=False):
        _result = []
        response = self.CLIENT.stream.statuses.filter.post(track='twitter', count=_limit)
        for data in response.stream():
            print data
            raise Exception(data)
            _result.append(data)
        return _result

