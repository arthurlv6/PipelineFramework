# PipelineFramework
Simple version pipeline with an example
# Why do we need pipeline?
Split a big logic into small pieces, which is easy to maintain and extend.
# How to use it?
There are two steps named definitions and execution.

Definitions include context, event and modules.<br>
Context is the data that will goes throgh from the beginning to the end. The context must inherit from PipelineContext.<br>
Event is the steps that you define based on your business requirement. The event must inherit from PipelineEvent.<br>
Module is the each step's implement in which your business logic. The module must inherit from PipelineModule<Event>.<br>

Execution is to call Backone.
