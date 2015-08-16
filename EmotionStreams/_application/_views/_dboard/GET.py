# -*- coding: utf-8 -*-

#! libraries : django views
from django.http import HttpResponseRedirect
from django.http import HttpResponse
from django.shortcuts import render
from django.shortcuts import render_to_response
from django.views.generic.base import View
from django.template import RequestContext

#! rest
from rest_framework.views import APIView
from rest_framework.response import Response

#! request
import requests
import json

#! libraries
from _application._procedures._Stream_Twitter_Lib import Stream_Twitter_Lib #! twitter stream
from _application._procedures._Stream_Parser_Lib import Stream_Parser_Lib #! stream parser
from _application._procedures._Stream_Catcher_Lib import Stream_Catcher_Lib #! stream save
from _application._procedures._Stream_Fetcher_Lib import Stream_Fetcher_Lib #! stream fetch
from _application._procedures._Stream_Interpreter_Lib import Stream_Interpreter_Lib #! stream interpreter


class Dboard(APIView):

    _template = 'dboard/index.html'

    def get(self, request, *args, **kwargs):

        '''
        return render_to_response(self._template,
                                 {'_streams': False},
                                 context_instance=RequestContext(request))
        '''

        #! stream initialization
        _instance_stream_twitter = Stream_Twitter_Lib()
        _stream = _instance_stream_twitter.Search__(['@mae_dessie'], 5)

        #! stream parsing
        _instance_stream_parser = Stream_Parser_Lib(_stream)
        _parsed_stream = _instance_stream_parser.Stream__()
        _parsed_batch = _instance_stream_parser.Batch__()

        #! database saving
        _instance_stream_catcher = Stream_Catcher_Lib(_parsed_batch, _parsed_stream)

        try:
            _instance_stream_catcher.CatchBatch__()
            _instance_stream_catcher.CatchStream__()
        except Exception as Error:
            return Response(str(Error))

        #! request
        _parsed_stream = json.dumps(_parsed_stream)
        _url = 'http://192.168.0.107:49312/api/messageemotion/GetMessageScores?localizationCode=en-US'
        _instance_stream_parser = Stream_Fetcher_Lib(_url, _parsed_stream)
        _analyzed_stream = _instance_stream_parser.Post__()

        #! interpreter
        _instance_stream_interpreter = Stream_Interpreter_Lib(eval(_analyzed_stream))
        __interpreted_stream = _instance_stream_interpreter.Interpreter__()

        #! results
        #return Response(_stream[0])
        #return Response(_parsed_stream)
        #return Response(_interpretation)

        return render_to_response(self._template,
                                 {'Streams_': __interpreted_stream},
                                 context_instance=RequestContext(request))