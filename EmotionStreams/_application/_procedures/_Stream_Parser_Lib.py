# -*- coding: utf-8 -*-
#! imports

#! libraries : birdy twitter api
from birdy.twitter import UserClient

#! models
from _application._models.Tbl_Batches import TblBatches


class Stream_Parser_Lib():

    def __init__(self, _stream):
        self.STREAM = _stream
        self.IDS = []

    def Stream__(self):
        _result = []
        for _data in self.STREAM[0]:
            self.IDS.append(_data['id'])
            _result.append({
                "stream_id": int(_data['id']),
                "batch_id": str(self.Generate__()),
                "profile_id": int(_data['user']['id']),
                "profile_pic": _data['user']['profile_image_url_https'],
                "profile_name": str(_data['user']['screen_name']),
                "text": _data['text'].encode('utf-8'),
                "time": _data['user']['created_at']
            })
        return _result

    def Batch__(self):
        _result = []
        _result.append({
            "id": int(self.Generate__()),
            "streams": self.IDS,
        })
        return _result

    def Generate__(self):
        _count = int(TblBatches.objects.all().count())
        _start = 12345678911122
        _next = _count + _start + 1
        return _next
