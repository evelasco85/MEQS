# -*- coding: utf-8 -*-
#! imports

#! libraries : birdy twitter api
from birdy.twitter import UserClient

#! models
from _application._models.Tbl_Batches import TblBatches
from _application._models.Tbl_Streams import TblStreams


class Stream_Interpreter_Lib():

    def __init__(self, _stream):
        self.STREAM = _stream

    #!
    '''
    .79 -- .98 = overjoyed
    .59 -- .78 = happy
    .35 -- .58 = surprised
    -.40 -- -.58 = shocked/afraid
    -.59 -- -.78 = something unexpected
    '''
    def Interpreter__(self):
        for stream in self.STREAM:
            print stream
            stream.update({
                "emotion_val": self.Dictionary__(stream['Score'])
            })
        return self.STREAM

    def Dictionary__(self, _score):
        if self.Overjoy__(_score):
            return 'joy'
        elif self.Happy__(_score):
            return 'happy'
        elif self.Surprise__(_score):
            return 'surprise'
        elif self.Shock__(_score):
            return 'shock'
        elif self.Unexpected__(_score):
            return 'unexpected'
        elif self.Neutral__(_score):
            return 'neutral'
        else:
            return 'neutral'

    def Overjoy__(self, _score):
        if _score >= .79:
            return True
        else:
            return False

    def Happy__(self, _score):
        if _score >= .59 and _score <= .78:
            return True
        else:
            return False

    def Surprise__(self, _score):
        if _score >= .35 and _score <= .58:
            return True
        else:
            return False

    def Shock__(self, _score):
        if _score <= -.40 and _score >= -.58:
            return True
        else:
            return False

    def Unexpected__(self, _score):
        if _score <= -.590 and _score >= -.78:
            return True
        else:
            return False

    def Neutral__(self, _score):
        if _score == 0:
            return True
        else:
            return False

