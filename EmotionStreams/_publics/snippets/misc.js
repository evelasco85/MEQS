$('.Stream-emotion-btn').on('click', function(){
    showthis = $(this).attr('data');
    $('.Stream-list').hide().fadeOut('slow');
    $('.Stream-'+ showthis +'-class').show()
})

$('.Stream-box').on('mouseenter', function(){
    $(this).children('.Stream-view').hide();
    $(this).children('.Stream-read').show();
})

$('.Stream-box').on('mouseleave', function(){
    $(this).children('.Stream-read').hide();
    $(this).children('.Stream-view').show();
})