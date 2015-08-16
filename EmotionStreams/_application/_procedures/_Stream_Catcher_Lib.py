# -*- coding: utf-8 -*-
#! imports

#! libraries : birdy twitter api
from birdy.twitter import UserClient

#! models
from _application._models.Tbl_Batches import TblBatches
from _application._models.Tbl_Streams import TblStreams


class Stream_Catcher_Lib():

    def __init__(self, _batch, _stream):
        self.BATCH = _batch
        self.STREAM = _stream

    def CatchBatch__(self):
        _wrapper = []
        batch = self.BATCH
        _wrapper.append(TblBatches(**batch[0]))
        try:
            TblBatches.objects.bulk_create(_wrapper)
        except Exception as Error:
            raise Error
        return True

    def CatchStream__(self):
        _wrapper = []
        for stream in self.STREAM:
            _wrapper.append(TblStreams(**stream))
        TblStreams.objects.bulk_create(_wrapper)
        return True
