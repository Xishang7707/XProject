let terminal;
let instance;
let inputBuffer = '';
let inputBufferCursorStartX = 0;
let inputBufferCursorStartY = 0;
let inputBufferCursorPoint = 0;
let lastInputBuffer = '';
let lastLineOutputLength = 0;
let lastInputEchoFlag = false;

function InitTerminal(inst, elid) {
    instance = inst;
    terminal = new Terminal({
        rendererType: 'canvas', // 渲染类型
        rows: 48, // 行数
        cols: 207,
        convertEol: true, // 启用时，光标将设置为下一行的开头
        scrollback: 10, // 终端中的回滚量
        disableStdin: false, // 是否应禁用输入。
        cursorStyle: 'underline', // 光标样式
        cursorBlink: true, // 光标闪烁
        theme: {
            foreground: 'yellow', // 字体
            background: '#060101', // 背景色
            cursor: 'help' // 设置光标
        }
    });
    terminal.open(document.getElementById(elid));
    terminal.onKey(d => {
        switch (d.domEvent.keyCode) {
            case 8:
                if (inputBufferCursorPoint == 0) break;
                var beforeInputBufferLength = inputBuffer.length;
                var beginBackchar = '\b'.repeat(inputBufferCursorPoint);
                TerminalWrite(beginBackchar);
                inputBuffer = inputBuffer.Remove(inputBufferCursorPoint - 1);
                TerminalWrite(inputBuffer);
                TerminalWrite(' ');
                TerminalWrite('\b'.repeat(beforeInputBufferLength - inputBufferCursorPoint + 1));
                --inputBufferCursorPoint;
                // console.log(beforeInputBufferLength - inputBufferCursorPoint + 1);
                // var endBackchar = '\b'.repeat(inputBufferCursorPoint.length);
                // var backBuffer = beginBackchar + ' '.repeat(inputBuffer.length) + endBackchar;//+ back;

                // inputBuffer = inputBuffer.Remove(--inputBufferCursorPoint);
                // console.log(backBuffer, backBuffer.length);
                // TerminalWrite(backBuffer);
                // TerminalWrite(inputBuffer);
                // TerminalWrite('\b'.repeat(inputBuffer.length - inputBufferCursorPoint.length));
                console.log(inputBuffer);
                break;
            case 13:
                lastInputBuffer = inputBuffer;
                inputBuffer = '';
                inputBufferCursorPoint = 0;
                lastInputEchoFlag = false;
                // if (lastInputBuffer.trim().length != 0)
                TerminalWrite('\r\n');
                console.log(lastInputBuffer);
                TerminalInput(lastInputBuffer);
                break;
            case 37://left
                if (!terminal.EnableMoveCursor('l')) break;
                var rows = terminal.InputBufferRows();
                if (rows > 1 && terminal._core.buffer.y > inputBufferCursorStartY && terminal._core.buffer.x == 0) {
                    TerminalWrite('\x1b[A' + '\x1b[C'.repeat(terminal.cols));
                } else {
                    TerminalWrite(d.key);
                }
                inputBufferCursorPoint--;
                break;
            case 39://right
                // if (inputBufferCursorPoint + 1 > inputBuffer.length) break;
                if (!terminal.EnableMoveCursor('r')) break;
                var rows = terminal.InputBufferRows();
                if (rows > 1 && terminal._core.buffer.x + 1 >= terminal.cols)
                    TerminalWrite('\x1b[B' + '\x1b[D'.repeat(terminal.cols));
                else {
                    TerminalWrite(d.key);
                }
                inputBufferCursorPoint++;
                break;
            case 71://g test
                terminal.SetCursorPos(inputBufferCursorStartX, inputBufferCursorStartY);
                break;
            default:
                console.log(d);
                var endBuffer = inputBufferCursorPoint == 0 ? '' : inputBufferCursorPoint == inputBuffer.length ? '' : inputBuffer.slice(inputBufferCursorPoint);
                console.log(endBuffer);
                inputBuffer = inputBuffer.Insert(inputBufferCursorPoint++, d.key);
                var cx = terminal._core.buffer.x;
                var cy = terminal._core.buffer.y;
                console.log('-1-', cx, cy);
                TerminalWrite(d.key + endBuffer);

                var rows = terminal.InputBufferRows();

                var mx = cx;
                var my = cy;
                if (inputBufferCursorStartY == cy && inputBuffer.length + lastLineOutputLength < terminal.cols) {
                    terminal.SetCursorPos(cx - endBuffer.length, cy);
                }
                else if (inputBufferCursorStartY == cy && inputBuffer.length + lastLineOutputLength == terminal.cols && endBuffer.length > 0) {
                    console.log(terminal.cols, cx, inputBuffer.length);
                    terminal.SetCursorPos(cx - endBuffer.length + 1, cy);
                } else if (inputBufferCursorStartY == cy && inputBuffer.length + lastLineOutputLength - terminal.cols > 1 && endBuffer.length > 0) {
                    terminal.SetCursorPos(cx + 1, cy - 2);
                    console.log(cx, cy);
                }
                else if (rows > 1) {
                    // if (inputBufferCursorStartY == terminal._core.buffer.y) { }
                }
                break;
        }

    });
    // terminal.onData(e => {
    //     console.log(e);
    // });
}

/**
 * 初始化
 */
function TerminalReload() {
    inputBuffer = '';
    lastInputBuffer = '';
    inputBufferCursorPoint = 0;
}

/**
 * 输出到终端
 * @param {string} str 
 */
function TerminalWrite(str) {
    terminal.writeUtf8(str);
}

/**
 * 输出到终端
 * @param {string} str 输出字符串
 */
function TerminalOutput(str) {
    var outputLines = str.split('\r\n');
    console.log(outputLines);
    var outputLineFilter = [];
    if (!lastInputEchoFlag
        && outputLines[0].trim() === lastInputBuffer.trim()) {
        lastInputEchoFlag = true;
        outputLineFilter = outputLines.length > 0 ? outputLines.slice(1) : [];
    }
    else {
        outputLineFilter = outputLines;
    }

    lastLineOutputLength = outputLineFilter[outputLineFilter.length - 1].length;
    terminal.writeUtf8(outputLineFilter.join('\r\n'));
    terminal.writeUtf8(inputBuffer);
    inputBufferCursorStartX = lastLineOutputLength;
    inputBufferCursorStartY = terminal._core.buffer.y + outputLineFilter.length - 1;
    console.log(inputBufferCursorStartX, inputBufferCursorStartY)
}

/**
 * 写入到shell
 * @param {stirng} str 
 */
function TerminalInput(str) {
    instance.invokeMethodAsync('TerminalWrite', str);
}

String.prototype.Insert = function (index, c) {
    return this.slice(0, index) + c + this.slice(index);
};

String.prototype.Remove = function (index) {
    return this.substring(0, index) + this.substring(index + 1, this.length);
}

Terminal.prototype.SetCursorPos = function (x, y) {
    var cx = terminal._core.buffer.x;
    var cy = terminal._core.buffer.y;
    var mvx = cx - x;
    var mvy = cy - y;

    var mvbuffer = '';

    if (mvy > 0) {
        mvbuffer += '\x1b[A'.repeat(mvy);
    } else if (mvy < 0) {
        mvbuffer += '\x1b[B'.repeat(-mvy);
    }
    if (mvx > 0) {
        mvbuffer += '\x1b[D'.repeat(mvx);
    } else if (mvx < 0) {
        mvbuffer += '\x1b[C'.repeat(-mvx);
    }

    this.write(mvbuffer);
}

Terminal.prototype.EnableMoveCursor = function (direct) {
    //u d l r
    //多行
    switch (direct) {
        case 'u': return this._core.buffer.y > inputBufferCursorStartY;
        case 'd': return this._core.buffer.y < inputBufferCursorStartY;
        case 'l':
            var bufferRows = this.InputBufferRows();
            if (inputBufferCursorStartY == this._core.buffer.y && this._core.buffer.x > inputBufferCursorStartX) return true;//同一行 可左
            if (bufferRows > 1 && (this._core.buffer.y - inputBufferCursorStartY) > 0) return true;//多行 不处于第一行
            console.log(inputBufferCursorStartY, bufferRows, this._core.buffer.y);
            return false;
        case 'r':
            var bufferRows = this.InputBufferRows();
            console.log(bufferRows);
            var lastLineLength = bufferRows <= 1 ? inputBuffer.length + lastLineOutputLength : lastLineOutputLength + inputBuffer.length - this.cols * (bufferRows - 1);
            console.log(lastLineLength);
            if (bufferRows == 1 && inputBufferCursorStartY == this._core.buffer.y && this._core.buffer.x < lastLineLength) return true;//第一行 可右
            if (bufferRows > 1 && inputBufferCursorStartY == this._core.buffer.y) return true;//第一行 可右
            if (bufferRows > 1 && inputBufferCursorStartY + bufferRows < this._core.buffer.y) return true;//多行 不处于最后一行
            if (inputBufferCursorStartY + bufferRows - 1 == this._core.buffer.y && this._core.buffer.x < lastLineLength) return true;//末行 不超过最后一行长度
            console.log(inputBufferCursorStartY, bufferRows, this._core.buffer.y, this._core.buffer.x, lastLineLength);
            return false;
        default: return false;
    }
}

Terminal.prototype.InputBufferRows = function () {
    return parseInt((lastLineOutputLength + inputBuffer.length) / this.cols) + ((lastLineOutputLength + inputBuffer.length) % this.cols > 0 ? 1 : 0);
}